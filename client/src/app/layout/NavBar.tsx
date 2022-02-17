import React from "react";
import { NavLink } from "react-router-dom";
import { Button, Container, Menu } from "semantic-ui-react";

export default function NavBar() {
	return (
		<Menu inverted fixed="top">
			<Container>
				<Menu.Item as={NavLink} to="/" header>
					<img src="/assets/logo.png" alt="logo" style={{ marginLeft: "12px" }} />
					<strong>Reactivities</strong>
				</Menu.Item>
				<Menu.Item name="Activities" as={NavLink} to="/activities" />
				<Menu.Item>
					<Button as={NavLink} to="/createActivity" positive content="Create Activity" />
				</Menu.Item>
			</Container>
		</Menu>
	);
}
