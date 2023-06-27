import api from "../api";

export const postLearn = async (payload: unknown): Promise<any> => {
  try {
    const response = await api.post("/learns", payload);
    return response;
  } catch (error) {
    console.error(error);
    return error;
  }
};

export const getLearn = async (page: number): Promise<any> => {
  try {
    const response = await api.get(
      `/learns/?limit=20&page=${page}&sortBy=createdAt:desc`
    );
    return response;
  } catch (error) {
    console.error(error);
    return error;
  }
};

export const deleteLearn = async (learnId: string): Promise<any> => {
  try {
    const response = await api.delete(`/learns/${learnId}`);
    return response;
  } catch (error) {
    console.error(error);
    return error;
  }
};
