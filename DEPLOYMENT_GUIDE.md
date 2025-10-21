# Deployment Guide - Portfolio React Application

## Prerequisites

1. **Azure Account** with:
   - Azure App Service for the API backend (existing)
   - Azure Static Web Apps for the React frontend (new)

2. **GitHub Secrets** configured:
   - `AZUREAPPSERVICE_PUBLISHPROFILE_CD19F3357B694E1D9878F2EFCFBD2206` (existing)
   - `AZURE_STATIC_WEB_APPS_API_TOKEN` (new - to be created)

## Setting up Azure Static Web Apps

### 1. Create Azure Static Web App

```bash
# Using Azure CLI
az staticwebapp create \
  --name portfolio-react-frontend \
  --resource-group <your-resource-group> \
  --source https://github.com/Tincho-dev/Portfolio \
  --location "East US 2" \
  --branch master \
  --app-location "portfolio-react" \
  --output-location "dist" \
  --login-with-github
```

### 2. Get Deployment Token

```bash
# Get the deployment token
az staticwebapp secrets list \
  --name portfolio-react-frontend \
  --query "properties.apiKey" \
  --output tsv
```

### 3. Add GitHub Secret

1. Go to your GitHub repository
2. Navigate to Settings → Secrets and variables → Actions
3. Click "New repository secret"
4. Name: `AZURE_STATIC_WEB_APPS_API_TOKEN`
5. Value: Paste the deployment token from step 2

## Deployment Process

### Automatic Deployment

The application uses GitHub Actions for CI/CD:

1. **Frontend Deployment**:
   - Triggered on push to `master` branch with changes in `portfolio-react/**`
   - Workflow: `.github/workflows/react-frontend-deploy.yml`
   - Builds React app with production environment
   - Deploys to Azure Static Web Apps

2. **Backend API Deployment**:
   - Triggered on push to `master` branch with changes in API/Services/Model/Repository
   - Workflow: `.github/workflows/master_martinlopezrubio.yml`
   - Builds .NET 8 API
   - Deploys to Azure App Service

### Manual Deployment

#### Frontend

```bash
# Navigate to React app
cd portfolio-react

# Install dependencies
npm install

# Build for production
npm run build

# Deploy using Azure Static Web Apps CLI
npm install -g @azure/static-web-apps-cli
swa deploy --app-location . --output-location dist --deployment-token <your-token>
```

#### Backend API

```bash
# Build and publish
dotnet publish PortfolioApi/PortfolioApi.csproj -c Release -o ./publish

# Deploy to Azure App Service
az webapp deployment source config-zip \
  --resource-group <your-resource-group> \
  --name MartinLopezRubio \
  --src ./publish.zip
```

## Environment Configuration

### Frontend Environment Variables

**Development** (`.env.development`):
```
VITE_API_URL=http://localhost:5000
```

**Production** (`.env.production`):
```
VITE_API_URL=https://martinlopezrubio.azurewebsites.net
```

### Backend CORS Configuration

Ensure the backend API allows the frontend domain in `PortfolioApi/Program.cs`:

```csharp
builder.Services.AddCors(options => options.AddPolicy(name:"ReactOrigin",
    policy =>
    {
        policy.WithOrigins(
            "http://localhost:5173",      // Local dev
            "http://localhost:3000",      // Alternative local
            "https://martinlopezrubio.azurewebsites.net",  // Production backend
            "https://<your-static-web-app>.azurestaticapps.net"  // Production frontend
        )
        .AllowAnyMethod()
        .AllowAnyHeader();   
    }));
```

## Verifying Deployment

### Frontend Checks

1. Navigate to your Azure Static Web App URL
2. Verify all pages load correctly
3. Test navigation between routes
4. Check browser console for errors

### Backend Checks

1. Access Swagger UI: `https://martinlopezrubio.azurewebsites.net/swagger`
2. Test API endpoints
3. Verify CORS headers in responses

### Integration Checks

1. Test API calls from frontend
2. Verify data loads correctly on all pages
3. Test state management across navigation
4. Check network tab for API responses

## Troubleshooting

### Issue: Frontend can't connect to API

**Solution**: 
- Check CORS configuration in backend
- Verify `VITE_API_URL` environment variable
- Check browser console for CORS errors

### Issue: Build fails in GitHub Actions

**Solution**:
- Check Node.js version (should be 20.x)
- Verify all dependencies are in package.json
- Check for TypeScript errors locally

### Issue: Static files not loading

**Solution**:
- Verify `base` in `index.html` is set to "/"
- Check public folder structure
- Ensure CSS/fonts are in public directory

### Issue: 404 on page refresh

**Solution**:
- Azure Static Web Apps should handle this automatically
- Verify `routes.json` or fallback configuration if needed

## Monitoring

### Azure Application Insights

Configure Application Insights for both frontend and backend:

1. Create Application Insights resource
2. Add instrumentation key to backend
3. Add browser tracking to frontend

### Log Streaming

```bash
# Stream backend logs
az webapp log tail --name MartinLopezRubio --resource-group <your-resource-group>

# Stream frontend logs
az staticwebapp show --name portfolio-react-frontend --resource-group <your-resource-group>
```

## Rollback Procedure

### Frontend

1. Go to Azure Static Web Apps in Azure Portal
2. Navigate to "Environments"
3. Select the deployment to rollback to
4. Click "Swap" or redeploy previous version

### Backend

1. Go to Azure App Service in Azure Portal
2. Navigate to "Deployment slots" or "Deployment Center"
3. Redeploy previous version from GitHub

## Cost Optimization

- Azure Static Web Apps Free tier includes:
  - 100 GB bandwidth/month
  - 0.5 GB storage
  - Suitable for this portfolio site

- Backend API on existing Azure App Service plan

## Security Considerations

1. **API Keys**: Store in GitHub Secrets, never in code
2. **CORS**: Restrict to known origins only
3. **HTTPS**: Enforce HTTPS in production
4. **Dependencies**: Regular security updates via Dependabot

## Support

For issues related to:
- React app: Check `portfolio-react/README.md`
- API: Check existing API documentation
- Deployment: Review GitHub Actions logs
