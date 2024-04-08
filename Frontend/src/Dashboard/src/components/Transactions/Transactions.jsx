import "./Transactions.css";
import { transactions } from "../../data/data";
import { iconsImgs } from "../../utils/images";
import profilepic from "../../assets/images/person_two.jpg";

const Transactions = () => {
  return (
    <div className="grid-one-item grid-common grid-c2">
        <div className="grid-c-title">
            <h3 className="grid-c-title-text">Profile Details</h3>
            <button className="grid-c-title-icon">
                <img src={ iconsImgs.plus } />
            </button>
        </div>

        <div className="grid-content">
            <div className="grid-items">
                {
                        <div className="grid-item">
                            <div className="grid-item-l">
                                <div className="avatar img-fit-cover">
                                    <img src={profilepic} alt="" />
                                </div>
                                <p className="text"> Habiba Mohamed Abdelrahman Salem<span> 22 Years Old</span></p>
                            </div>
                            <div className="grid-item-r">
                                <span className="text-scarlet"> No Medications</span>
                            </div>
                        </div>
                    
                }
            </div>
        </div>
    </div>
  )
}

export default Transactions
