import api from "../api";

export const getShippers = async () => {
    try {
        const response = await api.get(
            `/shippers`
        );
        return response;
    } catch (error) {
        console.error(error);
        return error;
    }
};