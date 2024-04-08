import { useEffect, useState } from 'react';
import { personsImgs } from '../../utils/images';
import { navigationLinks } from '../../data/data';
import "./Sidebar.css";
import { useContext } from 'react';
import { SidebarContext } from '../../context/sidebarContext';
import { Link, useLocation } from 'react-router-dom';

const Sidebar = () => {
  const [activeLinkIdx, setActiveLinkInd] = useState("");
  const [sidebarClass, setSidebarClass] = useState("");
  const { isSidebarOpen } = useContext(SidebarContext);

  const location = useLocation();

  useEffect(() => {
    handleLink()
    if (isSidebarOpen) {
      setSidebarClass('sidebar-change');
    } else {
      setSidebarClass('');
    }
  }, [isSidebarOpen]);

  const handleLink = () => {
   
   
     
    setActiveLinkInd(location.pathname.replace("/", ""));
    }
 

  return (
    <div className={`sidebar ${sidebarClass}`}>
      <div className="info-img img-fit-cover">
        <img src={personsImgs.person_two} alt="profile image" />
      </div>
      <span className="info-name">Habiba Mohamed</span>

      <nav className="navigation">
        <ul className="nav-list">
          {navigationLinks.map((navigationLink) => (
            <li className="nav-item" key={navigationLink.id}>
            
                <Link
                  to={'/' + navigationLink.title} 
                  className={`nav-link ${navigationLink.title === activeLinkIdx ? 'active' : ''}`}
              
                >
                  <img src={navigationLink.image} className="nav-link-icon" alt={navigationLink.title} />
                  <span className="nav-link-text">{navigationLink.title}</span>
                </Link>
              
            </li>
          ))}
        </ul>
      </nav>
    </div>
  )
}

export default Sidebar;
