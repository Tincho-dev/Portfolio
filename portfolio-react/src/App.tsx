import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import MainLayout from './components/Layout/MainLayout';

// Pages - will be created next
import Index from './pages/About/Index';
import Fuentes from './pages/Fuentes/Fuentes';
import Simulador from './pages/Simulador/Simulador';
import GithubProfile from './pages/GitHub/GithubProfile';
import Generador from './pages/NumerosAleatorios/Generador';

function App() {
  return (
    <Router>
      <MainLayout>
        <Routes>
          <Route path="/" element={<Index />} />
          <Route path="/fuentes" element={<Fuentes />} />
          <Route path="/simulador" element={<Simulador />} />
          <Route path="/githubprofile" element={<GithubProfile />} />
          <Route path="/githubprofile/:username" element={<GithubProfile />} />
          <Route path="/generador" element={<Generador />} />
          <Route path="*" element={<Navigate to="/" replace />} />
        </Routes>
      </MainLayout>
    </Router>
  );
}

export default App;
