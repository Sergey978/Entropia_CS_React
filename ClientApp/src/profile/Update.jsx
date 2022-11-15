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
            name="email"
            type="text"
            className={"form-control" + (errors.email ? " is-invalid" : "")}
          />
        </div>
        <h3 className="pt-3">Change Password</h3>
        <p>Leave blank to keep the same password</p>
        <div className="form-row">
          <div className="form-group col">
            <label>Password</label>
            <input
              name="password"
              type="password"
              className={
                "form-control" + (errors.password ? " is-invalid" : "")
              }
            />
          </div>
          <div className="form-group col">
            <label>Confirm Password</label>
            <input
              name="confirmPassword"
              type="password"
              className={
                "form-control" + (errors.confirmPassword ? " is-invalid" : "")
              }
            />
          </div>
        </div>
        <div className="form-group">
          <button type="submit" className="btn btn-primary mr-2">
            Update
          </button>
          <button
            type="button"
            onClick={() => onDelete()}
            className="btn btn-danger"
            style={{ width: "75px" }}
            disabled={isDeleting}
          >
            {isDeleting ? (
              <span className="spinner-border spinner-border-sm"></span>
            ) : (
              <span>Delete</span>
            )}
          </button>
          <Link to="." className="btn btn-link">
            Cancel
          </Link>
        </div>
      </form>
    </div>
  );
}

export { Update };
