import React from "react";
import { Link, NavLink } from "react-router-dom";
import { useForm } from "react-hook-form";

import { accountService, alertService } from "../_services";

function Login({ history, location }) {
  const {
    register,
    formState: { errors },
    getValues,
    handleSubmit,
  } = useForm({ mode: "onBlur" });

  const initialValues = {
    email: "",
    password: "",
  };

  function onSubmit({ email, password }) {
    alertService.clear();
    accountService
      .login(email, password)
      .then(() => {
        const { from } = location.state || { from: { pathname: "/" } };
        history.push(from);
      })
      .catch((error) => {       
        alertService.error(error);
      });
  }

  return (
    <section className="min-vh-100 d-flex bg-primary align-items-center mt-4">
      <div className="container">
        <div className="row justify-content-center">
          <div className="col-12 col-md-8 col-lg-6 justify-content-center">
            <div className="card bg-primary shadow-soft border-light p-4">
              <div className="card-header text-center pb-0">
                <h2 className="h4">Sign in to our platform</h2>
              </div>
              <div className="card-body">
                <form onSubmit={handleSubmit(onSubmit)} className="mt-4">
                  {/*<!-- Form -->*/}
                  <div className="form-group">
                    <label htmlFor="email">Your email</label>
                    <div className="input-group mb-4">
                      <div className="input-group-prepend">
                        <span
                          className={
                            "input-group-text" +
                            (errors.email ? "  border-danger" : "")
                          }
                        >
                          <span className="fas fa-envelope"></span>
                        </span>
                      </div>
                      <input
                        className={
                          "form-control" + (errors.email ? " is-invalid" : "")
                        }
                        id="email"
                        placeholder="example@company.com"
                        type="text"
                        aria-label="email adress"
                        {...register("email", {
                          required: true,
                          pattern:
                            /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
                        })}
                      />
                    </div>
                  </div>
                  {/*<!-- End of Form -->*/}
                  <div className="form-group">
                    {/*<!-- Form -->*/}
                    <div className="form-group">
                      <label htmlFor="password">Password</label>
                      <div className="input-group mb-4">
                        <div className="input-group-prepend">
                          <span
                            className={
                              "input-group-text" +
                              (errors.password ? "  border-danger" : "")
                            }
                          >
                            <span className="fas fa-unlock-alt"></span>
                          </span>
                        </div>
                        <input
                          className={
                            "form-control" +
                            (errors.password ? " is-invalid" : "")
                          }
                          id="password"
                          placeholder="Password"
                          type="password"
                          aria-label="Password"
                          {...register("password", {
                            required: "Password is required!",
                          })}
                        />
                      </div>
                    </div>
                    {/* <!-- End of Form -->*/}
                    <div className="d-block d-sm-flex justify-content-between align-items-center mb-4">
                      <div className="form-check">
                        <input
                          className="form-check-input"
                          type="checkbox"
                          value=""
                          id="defaultCheck5"
                        />
                        <label
                          className="form-check-label"
                          htmlFor="defaultCheck5"
                        >
                          Remember me
                        </label>
                      </div>
                      <div>
                        <a
                          href="#"
                          className="small text-right font-weight-bold text-info"
                        >
                          Lost password?
                        </a>
                      </div>
                    </div>
                  </div>
                  <button type="submit" className="btn btn-block btn-primary">
                    Sign in
                  </button>
                </form>

                <div className="d-block d-sm-flex justify-content-center align-items-center mt-4">
                  <span className="font-weight-normal mr-2">
                    Not registered?
                  </span>
                  <span>
                    <NavLink
                      to="/account/register"
                      className="font-weight-bold  text-info"
                    >
                      Create account
                    </NavLink>
                  </span>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
}

export { Login };
