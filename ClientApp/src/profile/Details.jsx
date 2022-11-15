import React from "react";
import { Link } from "react-router-dom";

import { accountService } from "../_services";

function Details({ match }) {
  const { path } = match;
  const user = accountService.userValue;

  return (
    <div className="row justify-content-center m-6">
      <div className="col-12 col-lg-8">
        <div>
          <h1>My Profile</h1>
          <p>
            <strong>Email: </strong> {user.email}
          </p>
          <p>
            <Link to={`${path}/update`}>Update Profile</Link>
          </p>
        </div>
      </div>
    </div>
  );
}

export { Details };
