import "./dashboard.css";
import Sidebar from "./layout/Sidebar/Sidebar";
import Content from "./layout/Content/Content";

function App({ role }) {

    return (
 
        <div className="app">
          <Sidebar role={role} />
          <Content role={role} />
        </div>
     
    );
 
 
}

export default App;
