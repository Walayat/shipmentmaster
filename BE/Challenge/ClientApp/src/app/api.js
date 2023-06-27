import axios from "axios";


const API_BASE_URL = "https://localhost:44476/api";


const api = axios.create({
    baseURL: API_BASE_URL,
});

api.interceptors.request.use(
    (config) => {
        const authObj = localStorage.getItem("shopping_portal");
        const auth = authObj ? JSON.parse(authObj) : {};
        config.headers = config.headers || {}; // Initialize headers if undefined
        if (auth) {
            const { access_token } = auth;
            if (access_token) {
                config.headers["Authorization"] = `Bearer ${auth.access_token}`;
                config.withCredentials = true;
            }
        }

        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

api.interceptors.response.use(
    (response) => {
        return response;
    },
    (error) => {
        return Promise.reject(error);
    }
);

export default api;
