import React, { useState } from "react";
import { iconsImgs } from "../../utils/images";
import "./Subscriptions.css";
import Calendar from "react-calendar";
import "react-calendar/dist/Calendar.css";

const Subscriptions = () => {
  const [date, setDate] = useState(new Date());

  const onChange = (date) => {
    setDate(date);
  };

  return (
    <div className="subgrid-two-item grid-common grid-c5">
      <div className="grid-c-title">
        <h3 className="grid-c-title-text">My Game Calendar</h3>
        <button className="grid-c-title-icon">
          <img src={iconsImgs.plus} alt="Add Icon" />
        </button>
      </div>
      <div className="grid-c5-content">
        <div className="calendar-container">
          <Calendar onChange={onChange} value={date} />
        </div>
      </div>
    </div>
  );
};

export default Subscriptions;
