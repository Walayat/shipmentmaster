import api from "../api";

export const SignIn = async (payload) => {
  try {
    const response = await api.post("/login", payload);

    return response; // Handle the response data
  } catch (error) {
    console.error(error); // Handle any errors
    return error;
  }
};

export const RegisterUser = async (payload) => {
  try {
    const response = await api.post("/register", payload);
    return response;
  } catch (error) {
    console.error(error);
    return error;
  }
};
