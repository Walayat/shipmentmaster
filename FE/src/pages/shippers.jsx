import { useEffect, useState } from "react";
import { Container, Row, Table } from "react-bootstrap";
import { useNavigate } from "react-router";
import "../../src/style.css";
import { getShippers } from "../app/features/shipper";
import NavBar from "../components/navbar";

export default function Shippers() {
    const router = useNavigate()
    const [shippers, setShippers] = useState([]);
    useEffect(() => {
        fetchData()
    }, [])

    async function fetchData() {
        let response = await getShippers();
        setShippers(response.data.data);
    }
    return (
        <>
            <NavBar />
            <div className="mb-5 mt-5">
                <Container>
                    <h5 className="text-left mb-4 ps-2">Shipper List</h5>
                    <Row>
                        <div className="col-9">
                            <Table bordered hover responsive="sm">
                                <thead>
                                    <tr>
                                        <th>Shipper Id</th>
                                        <th>Shipper Name</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {shippers.map((shipper) => (
                                        <tr className="cursor-pointer" key={shipper.shipper_id} onClick={() => router('/shipment/' + shipper.shipper_id)}>
                                            <td>{shipper.shipper_id}</td>
                                            <td>{shipper.shipper_name}</td>
                                        </tr>
                                    ))}
                                </tbody>
                            </Table>
                        </div>
                    </Row>
                </Container>
            </div>
        </>
    );


} 