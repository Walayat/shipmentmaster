import "../../src/style.css";
import { useEffect, useState } from "react";
import { getQuotesByAuthor } from "../app/features/quotable";
import { Container, Row, Table } from "react-bootstrap";
import NavBar from "../components/navbar";


export default function AuthorsQuotes() {
    const [quotes, setQuotes] = useState([]);
    useEffect(() => {
        fetchData()
    }, [])

    async function fetchData() {
        const payload = {
            author: "Albert Einstein",
            page: 1,
            limit: 30
        };
        let response = await getQuotesByAuthor(payload);
        setQuotes(response.data.data);
    }
    return (
        <>
            <NavBar />
            <div className="mb-5 mt-5">
                <Container>
                    <h5 className="text-left mb-4 ps-2">Quotes By Authors</h5>
                    <Row>
                        <div className="col-9">
                            <Table bordered hover responsive="sm">
                                <thead>
                                    <tr>
                                        <th>Author</th>
                                        <th>Content</th>
                                        <th>Author Slug</th>
                                        <th>Date Added</th>
                                        <th>Type</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {quotes?.shortResults?.map((quote) => (
                                        <tr key={quote._id}>
                                            <td>{quote.author}</td>
                                            <td>{quote.content}</td>
                                            <td>{quote.authorSlug}</td>
                                            <td>{quote.dateAdded}</td>
                                            <td>Short</td>
                                        </tr>
                                    ))}
                                    {quotes?.mediumResults?.map((quote) => (
                                        <tr key={quote._id}>
                                            <td>{quote.author}</td>
                                            <td>{quote.content}</td>
                                            <td>{quote.authorSlug}</td>
                                            <td>{quote.dateAdded}</td>
                                            <td>Medium</td>
                                        </tr>
                                    ))}
                                    {quotes?.longResults?.map((quote) => (
                                        <tr key={quote._id}>
                                            <td>{quote.author}</td>
                                            <td>{quote.content}</td>
                                            <td>{quote.authorSlug}</td>
                                            <td>{quote.dateAdded}</td>
                                            <td>Long</td>
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