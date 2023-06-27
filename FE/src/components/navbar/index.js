import Navbar from "react-bootstrap/Navbar";
import { Nav, Container } from "react-bootstrap";
import "./style.css";

const NavBar = () => {
  return (
    <Navbar expand="lg" bg="white" className="boxShadaw p-3">
      <Container>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav>
            <Nav.Link href="/">Home</Nav.Link>
            <Nav.Link href="/random-quote">Random Quote</Nav.Link>
            <Nav.Link href="/authors-quote">Authors Quotes</Nav.Link>
            <Nav.Link href="/shippers">Shippers</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default NavBar;
