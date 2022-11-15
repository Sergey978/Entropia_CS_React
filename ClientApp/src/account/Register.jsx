import React from "react";
import { NavLink } from "react-router-dom";
import { useForm } from "react-hook-form";

import { accountService, alertService } from "../_services";

function Register({ history }) {
  const {
    register,
    formState: { errors },
    getValues,
    handleSubmit,
  } = useForm({ mode: "onBlur" });

 
  function onSubmit(fields) {
    console.log("submitting...")
    accountService
      .register(fields)
      .then(() => {
        alertService.success(
          "Registration successful, please check your email for verification instructions",
          { keepAfterRouteChange: true }
        );
        history.push("login");
      })
      .catch((error) => {        
        alertService.error(error);
      });
  }

  return (
    <section className="min-vh-100 d-flex bg-primary align-items-center">
      <div className="container">
        <div className="row justify-content-center">
          <div className="col-12 col-md-8 col-lg-6 justify-content-center">
            <div className="card bg-primary shadow-soft border-light p-4">
              <div className="card-header text-center pb-0">
                <h2 className="mb-0 h5">Create Account</h2>
              </div>
              <div className="card-body">
                <form onSubmit={handleSubmit(onSubmit)}>
                  {/*<!-- Form  group-->*/}
                  <div className="form-group ">
                    <label htmlFor="exampleInputIcon4">Your email</label>
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
                        id="email"
                        name="email"
                        className={
                          "form-control" + (errors.email ? " is-invalid" : "")
                        }
                        {...register("email", {
                          required: true,
                          pattern:
                            /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
                        })}
                        placeholder="example@company.com"
                        type="text"
                        aria-label="email adress"
                      />
                    </div>
                  </div>
                  {/*<!-- End of Form group -->*/}
                  <div className="form-group">
                    {/*} <!-- Form group-->*/}
                    <div className="form-group">
                      <label htmlFor="exampleInputPassword7">Password</label>
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
                          name="password"
                          placeholder="Password"
                          type="password"
                          aria-label="Password"
                          {...register("password", {
                            required: "Password is required!",
                          })}
                        />
                      </div>
                    </div>
                    {/*<!-- End of Form  group-->*/}
                    {/*<!-- Form  group-->*/}
                    <div className="form-group">
                      <label htmlFor="exampleConfirmPassword7">
                        Confirm Password
                      </label>
                      <div className="input-group">
                        <div className="input-group-prepend">
                          <span
                            className={
                              "input-group-text" +
                              (errors.confirmPassword ? " border-danger" : "")
                            }
                          >
                            <span className="fas fa-unlock-alt"></span>
                          </span>
                        </div>
                        <input
                          className={
                            "form-control" +
                            (errors.confirmPassword ? " is-invalid" : "")
                          }
                          id="confirmPassword"
                          name="confirmPassword"
                          placeholder="Confirm password"
                          type="password"
                          aria-label="Password"
                          {...register("confirmPassword", {
                            required: "Please confirm password!",
                            validate: {
                              matchesPreviousPassword: (value) => {
                                const { password } = getValues();
                                return (
                                  password === value ||
                                  "Passwords should match!"
                                );
                              },
                            },
                          })}
                        />
                      </div>
                    </div>
                    {/*<!-- End of Form group-->*/}
                    <div className="form-check mb-4">
                      <input
                        className="form-check-input"
                        type="checkbox"
                        value=""
                        name="acceptTerms"
                        id="acceptTerms"
                        {...register("acceptTerms", {
                          required: "AcceptTerms is required!",
                        })}
                      />
                      <label
                        className={
                          "form-check-label" +
                          (errors.acceptTerms ? " text-danger" : "")
                        }
                        htmlFor="acceptTerms"
                      >
                        I agree to the <a href="#">terms and conditions</a>
                      </label>
                    </div>
                  </div>
                  <button type="submit" className="btn btn-block btn-primary">
                    Sign up
                  </button>
                </form>

                <div className="d-block d-sm-flex justify-content-center align-items-center mt-4">
                  <span className="font-weight-normal mr-2">
                    Already have an account?
                  </span>
                  <span className="font-weight-normal">
                    <NavLink to="/account/login" className="font-weight-bold text-info">
                      Login here
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

export { Register };
