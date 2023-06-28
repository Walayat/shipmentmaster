import "../../src/style.css";
import { useEffect, useState } from "react";
import { getRandomQuote } from "../app/features/quotable";
import NavBar from "../components/navbar";
import { Card } from "react-bootstrap";

export default function RandomQuote() {
    const [quote, setQuote] = useState({});
    useEffect(() => {
        fetchData()
    }, [])
    async function fetchData() {
        let response = await getRandomQuote();
        setQuote(response.data.data);
    }

    return (
        <>
            <NavBar />
            <Card className="p-4 mt-5 m-auto w-50">
                <Card.Header>
                    <h5 className="text-center">Random Quote Details</h5>
                </Card.Header>
                <Card.Body>
                    <div className="row mb-3">
                        <div className="col-3">
                            <b>Author Name:</b>
                        </div>
                        <div className="col-9">
                            <p>{quote.author}</p>
                        </div>
                    </div>
                    <div className="row mb-3">
                        <div className="col-3">
                            <b>Content:</b>
                        </div>
                        <div className="col-9">
                            <p>{quote.content}</p>
                        </div>
                    </div>
                    <div className="row mb-3">
                        <div className="col-3">
                            <b>Tags:</b>
                        </div>
                        <div className="col-9">
                            <p>{quote?.tags?.join(', ')}</p>
                        </div>
                    </div>
                    <div className="row mb-3">
                        <div className="col-3">
                            <b>Author Slug:</b>
                        </div>
                        <div className="col-9">
                            <p>{quote.authorSlug}</p>
                        </div>
                    </div>
                </Card.Body>
            </Card>

        </>
    )
}