import { useEffect, useState } from 'react';
import { personsImgs } from '../../utils/images';
import { navigationLinks } from '../../data/dataPatient';
import "./Sidebar.css";
import { useContext } from 'react';
import { SidebarContext } from '../../context/sidebarContext';
import { Link, useLocation } from 'react-router-dom';
import {navigationLinksDoctor} from '../../data/dataDoctor';
import { navigationLinksAdmin } from '../../data/dataAdmin';
const Sidebar = ({role}) => {
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
 
if (role=='Patient'){
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
else if(role=='Doctor')
{
  return (
    <div className={`sidebar ${sidebarClass}`}>
      <div className="info-img img-fit-cover">
        <img      src="https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?auto=format&fit=crop&w=286" alt="profile image" />
      </div>
      <span className="info-name">Dr. Mina Antoun</span>

      <nav className="navigation">
        <ul className="nav-list">
          {navigationLinksDoctor.map((navigationLink) => (
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
else if(role=='Admin')
{
  return (
    <div className={`sidebar ${sidebarClass}`}>
      <div className="info-img img-fit-cover">
        <img src="https://images.unsplash.com/flagged/photo-1573603867003-89f5fd7a7576?q=80&w=1946&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" alt="profile image" />
      </div>
      <span className="info-name">Dr. Nashaat Amir</span>

      <nav className="navigation">
        <ul className="nav-list">
          {navigationLinksAdmin.map((navigationLink) => (
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
}

export default Sidebar;
