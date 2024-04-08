import React from 'react';
import './footer.css';

const Footer = () => (
  <div className="gpt3__footer section__padding">
    <div className="gpt3__footer-heading">
      <h1 className="gradient__text">Do you want to step in and try our platform?</h1>
    </div>

    

    <div className="gpt3__footer-links">
      <div className="gpt3__footer-links_div">
        <h4>Links</h4>
        <p>Social Media</p>
        <p>Contact</p>
      </div>
      <div className="gpt3__footer-links_div">
        <h4>services</h4>
        <p>Terms & Conditions </p>
        <p>Privacy Policy</p>
        <p>Contact</p>
      </div>
      <div className="gpt3__footer-links_div">
        <h4>Get in touch</h4>
        <p>012345678</p>
        <p>info@MindMend.com</p>
      </div>
    </div>

    <div className="gpt3__footer-copyright">
      <p>@2024 MindMend. All rights reserved.</p>
    </div>
  </div>
);

export default Footer;
