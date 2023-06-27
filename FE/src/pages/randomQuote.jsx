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
            <Card className="p-4 mt-5 m-auto w-75">
                <div className="d-flex m-2">
                    <b className="m-2">Author Name: </b>
                    <p className="m-2">{quote.author}</p>
                </div>
                <div className="d-flex m-2">
                    <b className="m-2">Content: </b>
                    <p className="m-2">{quote.content}</p>
                </div>
                <div className="d-flex m-2">
                    <b className="m-2">Tags: </b>
                    <p className="m-2">{quote?.tags?.join(', ')}</p>
                </div>
                <div className="d-flex m-2">
                    <b className="m-2">Author Slug: </b>
                    <p className="m-2">{quote.authorSlug}</p>
                </div>
            </Card>
        </>
    )
}