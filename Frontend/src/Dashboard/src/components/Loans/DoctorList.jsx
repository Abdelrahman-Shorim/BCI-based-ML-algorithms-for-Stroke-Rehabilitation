import { iconsImgs } from "../../utils/images";
import "./Loans.css";

const DoctorList = () => {
  return (
    <div className="subgrid-two-item grid-common grid-c7 scroll" style={{height:'150rem'}}>
        <div className="grid-c-title">
            <h3 className="grid-c-title-text" >Doctors List</h3>
            <button className="grid-c-title-icon">
                <img src={iconsImgs.plus} />
            </button>
        </div>
        <div className="grid-c7-content" style={{position:'relative' , display:'grid' , paddingTop:'40px', gap: '25px'}}>
          <ul>Dr. Mina Antoun</ul>
          <ul>Dr. Mina Antoun</ul>
          <ul>Dr. Mina Antoun</ul>
          <ul>Dr. Mina Antoun</ul>
          <ul>Dr. Mina Antoun</ul>
          <ul>Dr. Mina Antoun</ul>
          <ul>Dr. Mina Antoun</ul>
          <ul>Dr. Mina Antoun</ul>
          <ul>Dr. Mina Antoun</ul>
          <ul>Dr. Mina Antoun</ul>
          <ul>Dr. Mina Antoun</ul>
          <ul>Dr. Mina Antoun</ul>
          <ul>Dr. Mina Antoun</ul>
          <ul>Dr. Mina Antoun</ul>
    </div>
    </div>
  )
}

export default DoctorList
