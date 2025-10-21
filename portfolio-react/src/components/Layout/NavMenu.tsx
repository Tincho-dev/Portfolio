import { FC, useState } from 'react';
import { Link, useLocation } from 'react-router-dom';
import styles from './NavMenu.module.scss';

interface NavMenuProps {
  showIconMenu?: boolean;
  onIconMenuToggle?: (active: boolean) => void;
}

const NavMenu: FC<NavMenuProps> = ({ onIconMenuToggle }) => {
  const [iconMenuActive, setIconMenuActive] = useState(false);
  const [collapseNavMenu, setCollapseNavMenu] = useState(true);
  const location = useLocation();

  const toggleNavMenu = () => {
    setCollapseNavMenu(!collapseNavMenu);
  };

  const toggleIconMenu = () => {
    const newState = !iconMenuActive;
    setIconMenuActive(newState);
    onIconMenuToggle?.(newState);
  };

  const isActive = (path: string) => {
    return location.pathname === path;
  };

  return (
    <>
      <div className={`${styles.topRow} top-row ps-3 navbar navbar-dark`}>
        <div className="container-fluid">
          <span className="oi oi-monitor" style={{ color: 'white' }} aria-hidden="true"></span>
          {!iconMenuActive && <a className="navbar-brand" href="">Portfolio</a>}
          <button 
            title="Navigation menu" 
            className="navbar-toggler" 
            onClick={toggleNavMenu}
          >
            <span className="navbar-toggler-icon"></span>
          </button>
        </div>
      </div>
      
      <div className={collapseNavMenu ? 'collapse' : ''} onClick={toggleNavMenu}>
        <nav className="flex-column">
          <div className="nav-item px-3">
            <Link 
              className={`nav-link ${isActive('/fuentes') ? 'active' : ''}`} 
              to="/fuentes"
            >
              <span className="oi oi-list" aria-hidden="true"></span>
              {!iconMenuActive && <label>Fuentes</label>}
            </Link>
          </div>
          <div className="nav-item px-3">
            <Link 
              className={`nav-link ${isActive('/simulador') ? 'active' : ''}`} 
              to="/simulador"
            >
              <span className="oi oi-plus" aria-hidden="true"></span>
              {!iconMenuActive && <label>Simulador</label>}
            </Link>
          </div>
          <div className="nav-item px-3">
            <Link 
              className={`nav-link ${isActive('/githubprofile') ? 'active' : ''}`} 
              to="/githubprofile"
            >
              <span className="oi oi-code" aria-hidden="true"></span>
              {!iconMenuActive && <label>GitHubApi</label>}
            </Link>
          </div>
          <div className="nav-item px-3">
            <a 
              className="nav-link" 
              href="https://github.com/Tincho-dev/Portfolio" 
              target="_blank"
              rel="noopener noreferrer"
            >
              <span className="oi oi-code" aria-hidden="true"></span>
              {!iconMenuActive && <label>Source</label>}
            </a>
          </div>
        </nav>
      </div>
      
      <div className={styles.bottomRow}>
        <div className={styles.iconMenuArrow}>
          {!iconMenuActive ? (
            <span 
              className="oi oi-arrow-left" 
              style={{ color: 'white' }} 
              onClick={toggleIconMenu}
            ></span>
          ) : (
            <span 
              className="oi oi-arrow-right" 
              style={{ color: 'white' }} 
              onClick={toggleIconMenu}
            ></span>
          )}
        </div>
      </div>
    </>
  );
};

export default NavMenu;
