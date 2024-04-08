import { iconsImgs } from "../../utils/images";
import "./Loans.css";

const PatientList = () => {
  return (
    <div className="subgrid-two-item grid-common grid-c7 scroll">
        <div className="grid-c-title">
            <h3 className="grid-c-title-text">Pateints List</h3>
            <button className="grid-c-title-icon">
                <img src={iconsImgs.plus} />
            </button>
        </div>
        <div className="grid-c7-content" style={{position:'relative' , display:'grid' , paddingTop:'40px', gap: '25px'}}>
          <ul>Habiba Mohamed</ul>
          <ul>Habiba Mohamed</ul>
          <ul>Habiba Mohamed</ul>
          <ul>Habiba Mohamed</ul>
          <ul>Habiba Mohamed</ul>
          <ul>Habiba Mohamed</ul>
          <ul>Habiba Mohamed</ul>
          <ul>Habiba Mohamed</ul>
          <ul>Habiba Mohamed</ul>
          <ul>Habiba Mohamed</ul>
          <ul>Habiba Mohamed</ul>
          <ul>Habiba Mohamed</ul>
          <ul>Habiba Mohamed</ul>
          <ul>Habiba Mohamed</ul>
          <ul>Habiba Mohamed</ul>
    </div>
    </div>
  )
}

export default PatientList
