import { FC, ReactNode, useState } from 'react';
import NavMenu from './NavMenu';
import styles from './MainLayout.module.scss';

interface MainLayoutProps {
  children: ReactNode;
}

const MainLayout: FC<MainLayoutProps> = ({ children }) => {
  const [iconMenuActive, setIconMenuActive] = useState(false);

  const handleIconMenuToggle = (active: boolean) => {
    setIconMenuActive(active);
  };

  return (
    <div className={styles.page}>
      <div 
        className={styles.sidebar} 
        style={iconMenuActive ? { width: '80px' } : undefined}
      >
        <NavMenu onIconMenuToggle={handleIconMenuToggle} />
      </div>
      <main>
        <article className="content px-4">
          {children}
        </article>
      </main>
    </div>
  );
};

export default MainLayout;
