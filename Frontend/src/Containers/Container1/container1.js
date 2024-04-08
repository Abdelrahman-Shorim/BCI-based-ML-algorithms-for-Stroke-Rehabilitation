import React from 'react';
import Feature from '../../LandingPage/feature/Feature';
import './container1.css';

const container1 = () => (
  <div className="gpt3__whatgpt3 section__margin" id="wgpt3">
    <div className="gpt3__whatgpt3-feature">
      <Feature title="What is MindMend?" text="Even if a neurological disorder limits physical movement, the power of imagination remains intact! Imagining hand movements triggers similar brain activity as real movements. That's where MindMend steps in! Using three types of neurofeedback, recoveriX enhances the chances of successful therapy.”" />
    </div>
    <div className="gpt3__whatgpt3-heading">
      <h1 className="gradient__text">MindMend is a unique combination of 3 therapies</h1>
     
    </div>
    <div className="gpt3__whatgpt3-container ">
      <Feature title="Motor Imagery" text="Imagine a hand or a foot movement. MindMend measures and analyses brain waves, which reflect the motor imagery and determines whether the motor imagery was correct.Once motor imagery has been recognized, virtual reality and Robotics will be activated.." />
      <Feature title="Virtual Reality" text="The simulation on the screen makes motor imagery visible. Patients sit in front of a screen, where they see hands and feet of an avatar and they are inside a game environment. This gives patients the feeling of watching their own movements and engaing in entertaining experience." />
      <Feature title="Robotics and Haptics" text="If the system recognizes a correct motor imagery, the robotic arm worn by the patient receives the right control signal, causing a real movement.This should help you re-learn how to initiate movement, and thus make movement possible again." />
    </div>
  </div>
);

export default container1;
