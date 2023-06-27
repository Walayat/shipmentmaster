import "../../src/style.css";
import { Container, Row, Table } from "react-bootstrap";
import { useEffect, useState } from "react";
import { getShipments } from "../app/features/shipment";
import { useParams } from "react-router";
import NavBar from "../components/navbar";

export default function Shipments() {
    const [shipments, setShipments] = useState([]);
    const param = useParams()

    useEffect(() => {
        if (param.id) {
            fetchData()
        }
    }, [param])

    async function fetchData() {
        let response = await getShipments(param.id);
        setShipments(response.data.data);
    }

    return (
        <>
            <NavBar />
            <div className="mb-5 mt-5">
                <Container>
                    <h5 className="text-left mb-4 ps-2">Shipment List</h5>
                    <Row>
                        <div className="col-9">
                            <Table bordered hover responsive="sm">
                                <thead>
                                    <tr>
                                        <th>Shipper Name</th>
                                        <th>Carrier Name</th>
                                        <th>Shipment Rate Description</th>
                                        <th>Shipment Description</th>
                                        <th>Shipment Weight</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {shipments.map((shipment) => (
                                        <tr key={shipment.shipper_id}>
                                            <td>{shipment.shipper_name}</td>
                                            <td>{shipment.carrier_name}</td>
                                            <td>{shipment.shipment_rate_description}</td>
                                            <td>{shipment.shipment_description}</td>
                                            <td>{shipment.shipment_weight}</td>
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