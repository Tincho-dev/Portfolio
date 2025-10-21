import { FC, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { useGitHubStore } from '../../stores/githubStore';

const GithubProfile: FC = () => {
  const { username } = useParams<{ username: string }>();
  const { user, repositories, loading, error, searchUser } = useGitHubStore();

  useEffect(() => {
    if (username) {
      searchUser(username);
    }
  }, [username]);

  return (
    <div>
      <h3>Github Profile</h3>
      
      {loading && <div>Loading...</div>}
      {error && <div className="alert alert-danger">{error}</div>}
      
      {user && (
        <div>
          <img src={user.avatar_url} alt={user.name} width="100" />
          <h4>{user.name}</h4>
          <p>{user.bio}</p>
        </div>
      )}

      {repositories.length > 0 && (
        <div>
          <h4>Repositories</h4>
          {repositories.map((repo) => (
            <div key={repo.id}>
              <h5>{repo.name}</h5>
              <p>{repo.description}</p>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default GithubProfile;
