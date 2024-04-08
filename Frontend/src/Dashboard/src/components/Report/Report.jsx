import { iconsImgs } from "../../utils/images";
import "./Report.css";
import { reportData } from "../../data/data";

const Report = () => {
  const months = ["Jan", "Feb", "Mar", "Apr", "May"];

  return (
    <div className="grid-one-item grid-common grid-c3">
        <div className="grid-c-title">
            <h3 className="grid-c-title-text">Treatment Progress</h3>
            <button className="grid-c-title-icon">
                <img src={ iconsImgs.plus } alt="Plus Icon" />
            </button>
        </div>
        <div className="grid-c3-content">
            <div className="grid-chart">
                <div className="chart-vert-value">
                    <span>100</span>
                    <span>75</span>
                    <span>50</span>
                    <span>25</span>
                    <span>0</span>
                </div>
                {
                    reportData.slice(0, 5).map((report, index) => (
                        <div className="grid-chart-bar" key={report.id}>
                            <div className="bar-wrapper">
                                <div className="bar-item1" style={{ height: `${report.value1 !== null ? "70%" : ""}` }}></div>
                                <div className="bar-item2" style={{ height: `${report.value2 !== null ? "77%" : ""}` }}></div>
                            </div>
                            <span className="grid-hortz-value">{months[index]}</span>
                        </div>
                    ))
                }
            </div>
        </div>
    </div>
  )
}

export default Report;
