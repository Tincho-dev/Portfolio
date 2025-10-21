import { apiClient } from './apiClient';
import { API_ENDPOINTS } from '../config/api.config';
import { GitHubUser, GitHubRepository } from '../models/GitHub';

export class GitHubService {
  async getUser(username: string): Promise<GitHubUser> {
    return apiClient.get<GitHubUser>(API_ENDPOINTS.github.user(username));
  }

  async getRepositories(username: string): Promise<GitHubRepository[]> {
    return apiClient.get<GitHubRepository[]>(API_ENDPOINTS.github.repositories(username));
  }
}

export const githubService = new GitHubService();
