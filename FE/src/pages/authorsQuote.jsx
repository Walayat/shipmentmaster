import "../../src/style.css";
import { useEffect, useState } from "react";
import { getQuotesByAuthor } from "../app/features/quotable";
import { Container, Row, Table } from "react-bootstrap";
import NavBar from "../components/navbar";
import DropdownComponent from "../components/dropdown";


export default function AuthorsQuotes() {
    const [quotes, setQuotes] = useState([]);
    const [category, setCategory] = useState("");

    useEffect(() => {
        fetchData(category)
    }, [category])

    async function fetchData(category) {
        const payload = {
            author: "Albert Einstein",
            page: 1,
            limit: 30,
            category: category === undefined ? "" : category
        };
        let response = await getQuotesByAuthor(payload);
        setQuotes(response.data.data);
    }
    return (
        <>
            <NavBar />
            <div className="mb-5 mt-5">
                <Container>
                    <Row>
                        <div className="col-9">
                            <h5 className="text-left mb-4 ps-2">Quotes By Authors</h5>
                        </div>
                        <div className="col-3 text-end">
                            <DropdownComponent category={category} setCategory={setCategory} />
                        </div>
                    </Row>
                    <Row>
                        <div className="col-12">
                            <Table bordered hover responsive="sm">
                                <thead>
                                    <tr>
                                        <th className="p-4 ali text-md font-semibold text-black font-display tracking-wide text-left" role="columnheader">Author</th>
                                        <th className="p-4 ali text-md font-semibold text-black font-display tracking-wide text-left" role="columnheader">Content</th>
                                        <th className="single-line p-4 ali text-md font-semibold text-black font-display tracking-wide text-left" role="columnheader">Author Slug</th>
                                        <th className="single-line p-4 ali text-md font-semibold text-black font-display tracking-wide text-left" role="columnheader">Date Added</th>
                                        <th className="p-4 ali text-md font-semibold text-black font-display tracking-wide text-left" role="columnheader">Type</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {quotes?.shortResults?.map((quote) => (
                                        <tr role="row" key={quote._id}>
                                            <td>{quote.author}</td>
                                            <td>{quote.content}</td>
                                            <td>{quote.authorSlug}</td>
                                            <td>{quote.dateAdded}</td>
                                            <td>Short</td>
                                        </tr>
                                    ))}
                                    {quotes?.mediumResults?.map((quote) => (
                                        <tr role="row" key={quote._id}>
                                            <td>{quote.author}</td>
                                            <td>{quote.content}</td>
                                            <td>{quote.authorSlug}</td>
                                            <td>{quote.dateAdded}</td>
                                            <td>Medium</td>
                                        </tr>
                                    ))}
                                    {quotes?.longResults?.map((quote) => (
                                        <tr role="row" key={quote._id}>
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