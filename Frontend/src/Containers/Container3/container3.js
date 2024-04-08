import React from 'react';
import cont3img from '../../Assets/container3img.png';
import './container3.css';

const container3 = () => (
  <div className="gpt3__possibility section__padding" id="possibility">
    <div className="gpt3__possibility-image">
      <img src={cont3img} alt="container3img" />
    </div>
    <div className="gpt3__possibility-content">
      <h4>You didn't get started yet?</h4>
      <h1 className="gradient__text">MindMend is a <br /> worldwide unique therapy!</h1>
      <p>MindMend stroke rehabilitation starts where the damage occurred: in the brain. The feedback loop from imagining to executing the movement is a very innovative and enjoyable way to reconnect brain cells.</p>
      
    </div>
  </div>
);

export default container3;
