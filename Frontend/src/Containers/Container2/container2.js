import React from 'react';
import Feature from '../../LandingPage/feature/Feature';
import './container2.css';

const featuresData = [
  {
    title: 'Acute Stage',
    text: 'Effective rehabilitation in the early stages is key to successful recovery, with patients benefiting from multiple therapies, making integration of MindMend crucial.',
  },
  {
    title: 'Sub-acute Stage',
    text: 'MindMend complements inpatient or outpatient rehab, enhancing physical and occupational therapy. It aids in achieving goals like holding a glass, biking to work, or reducing fatigue.',
  },
  {
    title: 'Chronic Stage',
    text: 'Our research indicates that with MindMend therapy, patients can experience ongoing improvement even 10 years post-stroke.',
  },
 
];

const container2 = () => (
  <div className="gpt3__features section__padding" id="features">
    <div className="gpt3__features-heading">
      <h1 className="gradient__text">Maximize your independence, It's never too late for rehabilitation!.</h1>
      
    </div>
    <div className="gpt3__features-container">
      {featuresData.map((item, index) => (
        <Feature title={item.title} text={item.text} key={item.title + index} />
      ))}
    </div>
  </div>
);

export default container2;
