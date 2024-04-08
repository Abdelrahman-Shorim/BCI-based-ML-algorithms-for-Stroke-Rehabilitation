import React from 'react';
import './header.css';
import headerimg from '../../Assets/headerimg.png';

const Header = () => (
  <div className="gpt3__header section__padding" id="home">
    <div className="gpt3__header-content">
      <h1 className="gradient__text">Rehabilitating the brain after a stroke and improving functional abilities</h1>
      <p>Discover MindMend, pioneering brain-computer tech that helps the brain relearn lost motor skills effortlessly.</p>
    </div>

    <div className="gpt3__header-image">
      <img src={headerimg} />
    </div>
  </div>
);

export default Header;
