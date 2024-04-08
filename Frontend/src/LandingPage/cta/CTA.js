import React from 'react';
import '../cta/cta.css';
import { useNavigate } from 'react-router-dom';
import { Link } from 'react-router-dom';
const CTA = () => {
  // const navigate=useNavigate();
  return(
  <div className="gpt3__cta">
    <div className="gpt3__cta-content">
      <h3>Register Today & start exploring MindMend.</h3>
    </div>
    <div className="gpt3__cta-btn">
     <Link to='/Signin'> <button type="button" >Get Started</button></Link>
    </div>
  </div>
  )

}

export default CTA;
