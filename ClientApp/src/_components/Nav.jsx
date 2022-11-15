import React, { useState, useEffect } from "react";
import { NavLink, Route, Link } from "react-router-dom";

import { Role } from "../_helpers";
import { accountService } from "../_services";

export const Nav = () => {
  const [user, setUser] = useState({});

  useEffect(() => {
    const subscription = accountService.user.subscribe((x) => setUser(x));
    return subscription.unsubscribe;
  }, []);

  // only show nav when logged in
  //if (!user) return null;
 
  return (
    <header className="header-global">
      <nav
        id="navbar-main"
        aria-label="Primary navigation"
        className="navbar navbar-main navbar-expand-lg navbar-theme-primary headroom navbar-light navbar-transparent navbar-theme-primary"
      >
        <div className="container position-relative">
          <a
            className="navbar-brand shadow-soft py-2 px-3 rounded border border-light mr-lg-4"
            href="./index.html"
          >
            <img
              className="navbar-brand-dark"
              src="./assets/img/brand/dark.svg"
              alt="Logo light"
            />
            <img
              className="navbar-brand-light"
              src="./assets/img/brand/dark.svg"
              alt="Logo dark"
            />
          </a>
          <div
            className="navbar-collapse collapse"
            id="navbar_global"
            onClick={onMenuItemClick}
          >
            <div className="navbar-collapse-header">
              <div className="row">
                <div className="col-6 collapse-brand">
                  <a
                    href="./index.html"
                    className="navbar-brand shadow-soft py-2 px-3 rounded border border-light"
                  >
                    <img
                      src="./assets/img/brand/dark.svg"
                      alt="Themesberg logo"
                    />
                  </a>
                </div>
                <div className="col-6 collapse-close">
                  <a
                    href="#navbar_global"
                    className="fas fa-times"
                    data-toggle="collapse"
                    data-target="#navbar_global"
                    aria-controls="navbar_global"
                    aria-expanded="false"
                    title="close"
                    aria-label="Toggle navigation"
                  ></a>
                </div>
              </div>
            </div>
            <ul className="navbar-nav navbar-nav-hover align-items-lg-center">
              <li className="nav-item">
                <NavLink to="/" className="nav-link">
                  <span className="nav-link-inner-text">Home</span>
                </NavLink>
              </li>
              <li className="nav-item">
                <NavLink to="/about" className="nav-link">
                  <span className="nav-link-inner-text">About</span>
                </NavLink>
              </li>

              {!user ? "": (
              <li className="nav-item dropdown">
                <a href="#" className="nav-link" data-toggle="dropdown">
                  <span className="nav-link-inner-text">Items</span>
                  <span className="fas fa-angle-down nav-link-arrow ml-2"></span>
                </a>
                <ul className="dropdown-menu">
                  <li>
                    <NavLink className="dropdown-item" to="/select-items">
                      Standart
                    </NavLink>
                  </li>
                  <li>
                    <NavLink className="dropdown-item" to="/custom-items">
                      Custom
                    </NavLink>
                  </li>
                  <li>
                    <NavLink className="dropdown-item" to="/graph-page">
                      Graph
                    </NavLink>
                  </li>
                </ul>
              </li>
              )}
            </ul>
          </div>
          {!user ? (
            <div className="d-flex align-items-center">
              <NavLink
                to="/account/register"
                className="btn btn-primary text-secondary d-none d-md-inline-block mr-3"
              >
                <i className="far fa-paper-plane mr-2"></i> Sign up
              </NavLink>
              <NavLink to="/account/login" className="btn btn-primary">
                <i className="fas fa-book"></i> Sign in
              </NavLink>
              <button
                className="navbar-toggler ml-2"
                type="button"
                data-toggle="collapse"
                data-target="#navbar_global"
                aria-controls="navbar_global"
                aria-expanded="false"
                aria-label="Toggle navigation"
              >
                <span className="navbar-toggler-icon"></span>
              </button>
            </div>
          ) : (
            <div className="d-flex align-items-center">
              <NavLink
                to="/profile"
                target="_blank"
                className="btn btn-primary text-secondary d-none d-md-inline-block mr-3"
              >
                <i className="far fa-paper-plane mr-2"></i>Profil
              </NavLink>
              <a
                onClick={accountService.logout}
                target="_blank"
                className="btn btn-primary text-secondary d-none d-md-inline-block mr-3"
              >
                <i className="far fa-paper-plane mr-2"></i>Sign out
              </a>

              <button
                className="navbar-toggler ml-2"
                type="button"
                data-toggle="collapse"
                data-target="#navbar_global"
                aria-controls="navbar_global"
                aria-expanded="false"
                aria-label="Toggle navigation"
              >
                <span className="navbar-toggler-icon"></span>
              </button>
            </div>
          )}
        </div>
      </nav>
      <Route path="/admin" component={AdminNav} />
    </header>
  );
};

//function for proper working mobile view
function onMenuItemClick() {
  document.getElementById("navbar_global")?.classList.remove("show");
}

function AdminNav({ match }) {
  const { path } = match;

  return (
    <nav className="admin-nav navbar navbar-expand navbar-light">
      <div className="navbar-nav">
        <NavLink to={`${path}/users`} className="nav-item nav-link">
          Users
        </NavLink>
      </div>
    </nav>
  );
}
