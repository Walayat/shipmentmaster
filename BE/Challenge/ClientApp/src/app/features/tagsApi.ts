import api from "../api";

export const addTags = async (payload: object): Promise<any> => {
  try {
    const response = await api.post("/tags/create", payload);
    return response;
  } catch (error) {
    console.error(error);
    return error;
  }
};

export const getTags = async (): Promise<any> => {
  try {
    const response = await api.get("/tags");
    return response;
  } catch (error) {
    console.error(error);
    return error;
  }
};

export const delTags = async (tagId: string): Promise<any> => {
  try {
    const response = await api.delete(`/tags/${tagId}`);
    return response;
  } catch (error) {
    console.error(error);
    return error;
  }
};

export const updateTag = async (
  tagId: string,
  payload: object
): Promise<any> => {
  try {
    const response = await api.patch(`/tags/${tagId}`, payload);
    return response;
  } catch (error) {
    console.error(error);
    return error;
  }
};
