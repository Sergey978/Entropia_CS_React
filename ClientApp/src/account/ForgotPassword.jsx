import React from "react";
import { Link } from "react-router-dom";
import { Formik, Field, Form, ErrorMessage } from "formik";
import * as Yup from "yup";

import { accountService, alertService } from "../_services";

function ForgotPassword() {
  const initialValues = {
    email: "",
  };

  const validationSchema = Yup.object().shape({
    email: Yup.string().email("Email is invalid").required("Email is required"),
  });

  function onSubmit({ email }, { setSubmitting }) {
    alertService.clear();
    accountService
      .forgotPassword(email)
      .then(() =>
        alertService.success(
          "Please check your email for password reset instructions"
        )
      )
      .catch((error) => alertService.error(error))
      .finally(() => setSubmitting(false));
  }

  return (
    <section className="min-vh-100 d-flex bg-primary align-items-center mt-4">
      <div className="container">
        <div className="row justify-content-center">
          <div className="col-12 col-md-8 col-lg-6 justify-content-center">
            <div className="card bg-primary shadow-soft border-light p-4">
              <div className="card-header text-center pb-0">
                <h2 className="h2">Forgot Password</h2>
              </div>
              <div className="card-body">
                <Formik
                  initialValues={initialValues}
                  validationSchema={validationSchema}
                  onSubmit={onSubmit}
                >
                  {({ errors, touched, isSubmitting }) => (
                    <Form>
                      <div className="card-body">
                        <div className="form-group">
                          <label>Email</label>
                          <Field
                            name="email"
                            type="text"
                            className={
                              "form-control" +
                              (errors.email && touched.email
                                ? " is-invalid"
                                : "")
                            }
                          />
                          <ErrorMessage
                            name="email"
                            component="div"
                            className="invalid-feedback"
                          />
                        </div>
                        <div className="form-row">
                          <div className="form-group col">
                            <button
                              type="submit"
                              disabled={isSubmitting}
                              className="btn btn-primary"
                            >
                              {isSubmitting && (
                                <span className="spinner-border spinner-border-sm mr-1"></span>
                              )}
                              Submit
                            </button>
                            <Link
                              to="login"
                              className="btn btn-danger float-sm-right"
                            >
                              Cancel
                            </Link>
                          </div>
                        </div>
                      </div>
                    </Form>
                  )}
                </Formik>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
}

export { ForgotPassword };
