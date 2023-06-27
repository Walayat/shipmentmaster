import "./style.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import NavBar from "./components/navbar";
import AuthorsQuotes from "./pages/authorsQuote";
import RandomQuote from "./pages/randomQuote";
import Shipments from "./pages/shipment";
import Shippers from "./pages/shippers";

function App(props) {

  return (
    <Router>
      <div id="App">
        <Routes>

          <Route path="/" element={<NavBar />} />
          <Route exact path="/authors-quote" element={<AuthorsQuotes />}></Route>
          <Route exact path="/random-quote" element={<RandomQuote />}></Route>
          <Route
            path="/shipment/:id"
            element={<Shipments />}
          ></Route>
          <Route path="/shippers" element={<Shippers />}></Route>
        </Routes>
      </div>
    </Router>
  );
}

export default App;
