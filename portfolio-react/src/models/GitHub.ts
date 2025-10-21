// GitHub models

export interface GitHubUser {
  login: string;
  id: number;
  avatar_url: string;
  name: string;
  company?: string;
  blog?: string;
  location?: string;
  email?: string;
  bio?: string;
  public_repos: number;
  followers: number;
  following: number;
}

export interface GitHubRepository {
  id: number;
  name: string;
  full_name: string;
  description?: string;
  html_url: string;
  language?: string;
  stargazers_count: number;
  forks_count: number;
  updated_at: string;
  topics: string[];
}
