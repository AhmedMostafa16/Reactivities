import React from "react";
import { Button, Item, Label, Segment } from "semantic-ui-react";
import { Activity } from "../../../app/models/activity";

interface Props {
	activities: Activity[];
	selectActivity: (id: string) => void;
	closeForm: () => void;
	deleteActivity: (id: string) => void;
}

export default function ActivityList(props: Props) {
	return (
		<Segment>
			<Item.Group divided>
				{props.activities.map((activity: Activity) => (
					<Item key={activity.id}>
						<Item.Content>
							<Item.Header as="a">{activity.title}</Item.Header>
							<Item.Meta>{activity.date}</Item.Meta>
							<Item.Description>
								<div>{activity.description}</div>
								<div>
									{activity.city}, {activity.venue}
								</div>
							</Item.Description>
							<Item.Extra>
								<Button
									onClick={() => {
										props.closeForm();
										props.selectActivity(activity.id);
									}}
									floated="right"
									content="View"
									color="blue"
								/>
								<Button
									onClick={() => props.deleteActivity}
									floated="right"
									content="Delete"
									color="red"
								/>
								<Label basic content={activity.category} />
							</Item.Extra>
						</Item.Content>
					</Item>
				))}
			</Item.Group>
		</Segment>
	);
}
