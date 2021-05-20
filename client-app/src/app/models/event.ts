import { Profile } from "./profile";


export interface Event {
    id: string;
    name: string;
    date: Date | null;
    description: string;
    hostUsername: string;
    isCancelled: boolean;
    isGoing: boolean;
    isHost: boolean;
    host?: Profile;
    attendees: Profile[]
}

export class Event implements Event {
    constructor(init?: EventFormValues) {
        Object.assign(this, init);
    }
}

export class EventFormValues {
    id?: string = undefined;
    name: string = '';
    date: Date | null = null;
    description: string = '';

    constructor(event?: EventFormValues) {
        if(event) {
            this.id = event.id;
            this.name = event.name;
            this.date = event.date;
            this.description = event.description;
        }
    }
}