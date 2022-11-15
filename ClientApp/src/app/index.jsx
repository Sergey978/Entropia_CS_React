import React, { useState, useEffect } from "react";
import { Route, Switch, Redirect, useLocation } from "react-router-dom";
//TODO: import all components to route
import { Role } from "../_helpers";
import { accountService } from "../_services";
import { Nav, PrivateRoute, Alert } from "../_components";
import { Home } from "../home";
import { About } from "about";
import { SelectItemsPage } from "../select-items";
import { CustomItemsPage } from "../custom-items";
import { Profile } from "../profile";
import { Admin } from "../admin";
import { Account } from "../account";
import { GraphPage } from "../graph";

function App() {
  const { pathname } = useLocation();
  const [user, setUser] = useState({});

  useEffect(() => {
    const subscription = accountService.user.subscribe((x) => setUser(x));
    return subscription.unsubscribe;
  }, []);
  //TODO: route all menu items (hide unauthorized routes )
  return (
    <div className={"app-container" + (user && " bg-light")}>
      <Nav />
      <Alert />
      <Switch>
        <Redirect from="/:url*(/+)" to={pathname.slice(0, -1)} />
        <Route exact path="/" component={Home} />
        <Route exact path="/about" component={About} />
        <Route exact path="/select-items" component={SelectItemsPage} />
        <Route exact path="/custom-items" component={CustomItemsPage} />
        <Route exact path="/graph-page" component={GraphPage} />  
        <Route path="/account" component={Account} />
        <PrivateRoute path="/profile" component={Profile} />
        <PrivateRoute path="/admin" roles={[Role.Admin]} component={Admin} />

        <Redirect from="*" to="/" />
      </Switch>
    </div>
  );
}

export { App };
