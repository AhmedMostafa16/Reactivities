import { Grid } from "semantic-ui-react";
import ActivityList from "./ActivityList";
import { useStore } from "../../../app/stores/store";
import { observer } from "mobx-react-lite";
import LoadingComponent from "../../../app/layout/LoadingComponent";
import React, { useEffect } from "react";

export default observer(function ActivityDashboard() {
	const { activityStore } = useStore();
	const { activityRegistry, loadActivities, loadingInitial } = activityStore;

	useEffect(() => {
		if (activityRegistry.size <= 1) loadActivities();
	}, [activityRegistry.size, loadActivities]);

	if (loadingInitial) return <LoadingComponent content="Loading app" />;
	return (
		<Grid>
			<Grid.Column width="10">
				<ActivityList />
			</Grid.Column>
			<Grid.Column width="6">
				<h2>Activity Filters</h2>
			</Grid.Column>
		</Grid>
	);
});
