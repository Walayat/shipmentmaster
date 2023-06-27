
import React, { useState } from "react"
import { useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import usePersist from "../hooks/usePersist";
import { SignIn } from "../app/features/authApi";

export default function Login() {
    const [_, setAuth] = usePersist('shopping_portal')
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm();

    const navigate = useNavigate();

    function changeAuthMode() {
        navigate('/register', { replace: true });
    }

    const onFormSubmit = (async (data) => {
        //setLoading(true);
        const result = await SignIn(data);
        // setLoading(false);
        if (result?.status === 200) {
            // Toaster({ message: "Logged in successfully", type: "success" });
            setAuth(result.data);
            setTimeout(() => {
                navigate("/home");
            }, 1000);
            return;
        }
        // Toaster({ message: result?.message, type: "error" });
        return;
    });


    return (
        <div className="Auth-form-container">
            <form className="Auth-form" onSubmit={handleSubmit(onFormSubmit)}>
                <div className="Auth-form-content">
                    <h3 className="Auth-form-title">Sign In</h3>
                    <div className="text-center">
                        Not registered yet?{" "}
                        <span className="link-primary" onClick={changeAuthMode}>
                            Sign Up
                        </span>
                    </div>
                    <div className="form-group mt-3">
                        <label htmlFor="email">Email</label>
                        <input
                            type="email"
                            id="email"
                            name="email"
                            className="form-control mt-1"
                            placeholder="Enter email"
                            {...register('email', { required: true })}
                        />
                    </div>
                    <div className="form-group mt-3">
                        <label htmlFor="password">Password</label>
                        <input
                            type="password"
                            id="password"
                            name="password"
                            className="form-control mt-1"
                            placeholder="Enter password"
                            {...register('password', { required: true })}
                        />
                    </div>
                    <div className="d-grid gap-2 mt-3">
                        <button type="submit" className="btn btn-primary">
                            Submit
                        </button>
                    </div>
                    <p className="text-center mt-2">
                        Forgot <a href="#">password?</a>
                    </p>
                </div>
            </form>
        </div>
    )

}
