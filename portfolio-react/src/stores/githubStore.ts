import { create } from 'zustand';
import { GitHubUser, GitHubRepository } from '../models/GitHub';
import { githubService } from '../services/githubService';

interface GitHubState {
  user: GitHubUser | null;
  repositories: GitHubRepository[];
  loading: boolean;
  error: string | null;
  searchUser: (username: string) => Promise<void>;
}

export const useGitHubStore = create<GitHubState>((set) => ({
  user: null,
  repositories: [],
  loading: false,
  error: null,
  searchUser: async (username: string) => {
    set({ loading: true, error: null });
    try {
      const user = await githubService.getUser(username);
      const repositories = await githubService.getRepositories(username);
      set({ user, repositories, loading: false });
    } catch (error) {
      set({ error: 'Error fetching GitHub data', loading: false, user: null, repositories: [] });
    }
  },
}));
