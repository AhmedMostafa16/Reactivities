import React, { ChangeEvent, useState } from "react";
import { Button, Form, Segment } from "semantic-ui-react";
import { Activity } from "../../../app/models/activity";

interface Props {
	activity: Activity | undefined;
	closeForm: () => void;
	createOrEdit: (activity: Activity) => void;
}

export default function ActivityForm(props: Props) {
	const initialState = props.activity ?? {
		id: "",
		title: "",
		category: "",
		description: "",
		date: "",
		city: "",
		venue: "",
	};

	const [activity, setActivity] = useState<Activity>(initialState);

	function handleSubmit() {
		props.createOrEdit(activity);
	}

	function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
		const { name, value } = event.target;
		setActivity({ ...activity, [name]: value });
	}

	return (
		<Segment clearing>
			<Form onSubmit={handleSubmit} autoComplete="off">
				<Form.Input
					placeholder="Title"
					value={props.activity?.title}
					onChange={handleInputChange}
					name="title"
				/>
				<Form.TextArea
					placeholder="Description"
					value={props.activity?.title}
					onChange={handleInputChange}
					name="description"
				/>
				<Form.Input
					placeholder="Category"
					value={props.activity?.category}
					onChange={handleInputChange}
					name="category"
				/>
				<Form.Input
					placeholder="Date"
					value={props.activity?.date}
					onChange={handleInputChange}
					name="date"
				/>
				<Form.Input
					placeholder="City"
					value={props.activity?.city}
					onChange={handleInputChange}
					name="city"
				/>
				<Form.Input
					placeholder="Venue"
					value={props.activity?.venue}
					onChange={handleInputChange}
					name="venue"
				/>

				<Button floated="right" positive type="submit" content="Submit" />
				<Button onClick={props.closeForm} floated="right" type="button" content="Cancel" />
			</Form>
		</Segment>
	);
}
