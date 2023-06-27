import { useState, useEffect } from "react";

const usePersist = (key) => {
    const [persist, setPersist] = useState(
        JSON.parse(localStorage.getItem(key || "persist")) || false
    );

    function setStorage() {
        localStorage.setItem(key || "persist", JSON.stringify(persist));
    }

    useEffect(() => {
        setStorage();
    }, [persist, key]);

    return [persist, setPersist];
};
export default usePersist;