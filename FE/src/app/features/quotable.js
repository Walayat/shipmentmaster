import api from "../api";

export const getRandomQuote = async () => {
    try {
        const response = await api.get(
            `/getRandomQuote`
        );
        return response;
    } catch (error) {
        console.error(error);
        return error;
    }
};

export const getQuotesByAuthor = async (req) => {
    const { author, page, limit, category } = req;

    try {
        const response = await api.get(
            `/getQuotesByAuthor?author=${author}&page=${page}&limit=${limit}&category=${category}`
        );
        return response;
    } catch (error) {
        console.error(error);
        return error;
    }
};

