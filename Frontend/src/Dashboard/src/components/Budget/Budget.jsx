import "./Budget.css";
import { iconsImgs } from "../../utils/images";
import { budget } from "../../data/data";

const comments = [
  "There is a significant progress in the right hand functionality",
  "Excellent progress in the patient's recovery",
  "Patient's condition is stable",
  "Improvement observed in mobility",
  "Recovery is slower than expected",
  
];

const Budget = () => {
  return (
    <div className="grid-two-item grid-common grid-c4">
      <div className="grid-c-title">
        <h3 className="grid-c-title-text">Doctor Comments</h3>
        <button className="grid-c-title-icon">
          <img src={iconsImgs.plus} alt="Plus Icon" />
        </button>
      </div>
      <div className="grid-c4-content bg-jet">
        <div className="grid-items">
          {budget.map((budgetItem, index) => (
            <div className="grid-item" key={budgetItem.id}>
              <div className="grid-item-l">
                <div className="icon">
                  <img src={iconsImgs.check} alt="Check Icon" />
                </div>
                <p className="text text-silver-v1">{comments[index]}</p>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default Budget;
