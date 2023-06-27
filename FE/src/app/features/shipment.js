import api from "../api";

export const getShipments = async (shipperId) => {
    try {
        const response = await api.get(
            `/shipments/${shipperId}`
        );
        return response;
    } catch (error) {
        console.error(error);
        return error;
    }
};