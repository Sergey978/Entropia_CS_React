import React, { useState } from "react";
import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";

import { accountService, alertService } from "../_services";

function Update({ history }) {
  const user = accountService.userValue;

  const {
    register,
    formState: { errors },
    getValues,
    handleSubmit,
  } = useForm({ mode: "onBlur" });

  function onSubmit(fields) {
    accountService
      .update(user.id, fields)
      .then(() => {
        alertService.success("Update successful", {
          keepAfterRouteChange: true,
        });
        history.push(".");
      })
      .catch((error) => {
        alertService.error(error);
      });
  }

  const [isDeleting, setIsDeleting] = useState(false);
  function onDelete() {
    if (confirm("Are you sure?")) {
      setIsDeleting(true);
      accountService
        .delete(user.id)
        .then(() => alertService.success("Account deleted successfully"));
    }
  }

  return (
    <div className="m-6">
      <form onSubmit={handleSubmit(onSubmit)}>
        <h1>Update Profile</h1>

        <div className="form-group">
          <label>Email</label>
          <input
            id="email"
            name="email"
            type="text"
            className={"form-control" + (errors.email ? " is-invalid" : "")}
            {...register("email", {
              pattern:
                /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
            })}
          />
        </div>
        <h3 className="pt-3">Change Password</h3>
        <p>Leave blank to keep the same password</p>
        <div className="form-row">
          <div className="form-group col">
            <label>Password</label>
            <input
              id="password"
              name="password"
              type="password"
              className={
                "form-control" + (errors.password ? " is-invalid" : "")
              }
              {...register("password", {})}
            />
          </div>
          <div className="form-group col">
            <label>Confirm Password</label>
            <input
              id="confirmPassword"
              name="confirmPassword"
              type="password"
              className={
                "form-control" + (errors.confirmPassword ? " is-invalid" : "")
              }
              {...register("confirmPassword", {
                validate: {
                  matchesPreviousPassword: (value) => {
                    const { password } = getValues();
                    return password === value || "Passwords should match!";
                  },
                },
              })}
            />
          </div>
        </div>
        <div className="form-group">
          <button type="submit" className="btn btn-primary mr-2">
            Update
          </button>

          <button className="btn btn-danger" style={{ width: "75px" }}>
            <Link to=".">
              <span>Cancel</span>
            </Link>
          </button>
        </div>
      </form>
    </div>
  );
}

export { Update };
