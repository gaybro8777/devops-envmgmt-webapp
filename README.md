# Environment Management Tool

## Goal
This is what I am to complete with this project:  The requirements for an Environment Tracking and Request System (ETRS).  The goal is to foremost, keep track of what application releases are in which environments, with what version, along with metadata like: Database name it communicates with, IP Address of server, URL of application if applicable, Port numbers, etc.

The Environment Dashboard should show the following information:

* Application Name
* Application Version number
* Environment Name
* Environment IP Address
* Associated Database Name
* Version of Database (if applicable)
* Owner of Application
* Status of Environment (Offline, Online, Refresh in Progress, etc.)
* A REST API should be exposed to update the Dashboard when the environment is refreshed or updated.
* A webform should be created to update the Environment dashboard manually

Next, is keeping track of usage of the environment for testing, validation, or other testing purposes.  A request form should have the following data elements:

* Requestor (automatically filled in)
* Usage Owner:  Who will officially own the usage effort (could be the same as Requestor)
* Project Team
* Release (March-2018, April-2018, ... Dec-2018)
* Application Name
* Application Version number
* Environment Name
* Database version needed
* Start Day requested
* Start Time requested for that day
* End Day requested
* End Time requested for End Day
* Misc notes
* Maybe, ask for Source Environment for both Application and Database

\* For Integration Testing with other applications, a new Env. Request form will need to be submitted.  Add to the Misc. Notes section that a request is related to another request.

The Dashboard for environment usage request will show the same information as the Environment Request form, in addition:

* Approval Status (Submitted, Under Review, Need more Info, Accepted, Rejected, Closed)
* Reasons text area field
* Link to Environment Request record with history of comments going back and forth between Requestor and Environment Management Team/Person
* Form to be able to update Environment request to be resubmitted or updated.
* Notifications via application notification system, email, or misc method (for example, sending a message via Slack or text message) of updated Request Form.


The screen to evaluate the Environment Request form will enable the Environment Manager or Team Member to:

* Review the Environment Request record
* Immediately Accept, Reject, or ask for more information from the Requestor
* Any conflicts will show and be filterable from those:  Already approved, Under Review Approval (all other states except Closed: Submitted, Under Review, Need fore Info)
* Generate a report of conflicts
* Generate a report of Approved, etc.


Finally, and Environment Usage Timeline Dashboard.  This will show a high level timeline view of the environment similar to a Gantt Chart, with the X-Axis being individual Days with the following features:

* Y-Axis will be the Project Team - Release - Application – Environment from the Environment Request record.
* The Y-Axis will be able to be grouped by Project Team - Release - Application Name or Environment (Gantt Chart will also group accordingly)
* The Y-Axis grouping will be able to change(for ex: Release - Env - Application, or any combination thereof)
* X-Axis scale will be able to change from Month view all the way down to Day (or hour view)
* Gantt Chart bar will hold the label of Application Abbreviation and Version Number.  Mouse over will show Usage owner and description of usage effort.  Double-Clicking of Gantt Chart bar or Y-Axis Application-Environment name will take user to detail Environment Request form.


** Please note that this system does not keep track of Environment Refresh requests.  Environment Request form should take into consideration the time it takes for the refresh process.  Some teams can do their own deployments.  Maybe the Environment Request dashboard should include a new status of ‘Refresh Requested’ and “Refresh Completed”.

## Phase 2
If I ever get this project completed, my second phase would to build a Release Management tool that would basically be a glorified Project scheduler with tasks, subtasks, Gantt Chart to show the activities.  Then an interface where tasks can be picked up, updatd when completed.  While all the time a dashboard shows how much time has elapsed, remaining, and various metrics about tasks done, in progress, issues, etc.  This will interface with the applications and their locations in the environments. When an application has been migrated to Production successfully, it will then update the Environment Dashboard.

## Breadown of Work Effort
| Type          | Description   | Hours | Notes |
|---------------|---------------|-------|-------|
| Design        | "Database schema design, creation" | 4     | Done  |
| Design        | data layer communication           | 4     | Done  |
| Code          | data layer creation and test       | 12    | Done  |
|               |                                    |       |       |
| Dashboard     | View of environments and applications currently installed.  | 8     |    |
| Function      | REST API to accept updates         | 16    | Done   |
| Data Entry    | Webform to update the environment dashboard | 8     |       |
|               |                                             |       |       |
|               |                                             |       |       |
| Data Entry    | Request form for Env. Usage                 | 2     |       |
| Dashoard      | "In User's profile, show list of pending requests"  | 2     |       |
|               |                                             |       |       |
| Dashboard     | "List of Pending requests. Also, show conflicts"    | 8     |       |
|               |                                             |       |       |
| Data Entry    | "Link from pending requests shows request details.  Add ability to accept, reject, pending review, need more info.  When in 'need more info', save comment history, notify requestor that request record needs to be updated after reading response for Environment Mgr." | 16    |       |
| Function      | Notification system will notify user or issues or RT of pendng requests.  | 8     |       |
| Report        | Generate a report of conflicts              | 16    |       |
| Report        | Generate a report of Approved requests      | 16    |       |
|               |                                             |       |       |
|               |                                             |       |       |
| Dashboard     | Environment Usage Timeline - Gantt Chart    | 16    |       |
| """"          | "Y-Axis will able to be modified show/hide and hairarchy, reorder columns"| 16    |       |
| """"          | Zoom in and out altering X-Axis timeine size and details (Month to hours) | 2     |       |
| SubTotal      |                                             | 154   |       |
|               |                                             |       |       |
| Function      | Security system - profile pages and interface with LDAP     | 24    |       |
| Function      | Notification System                         | 20    |       |
| Testing       | Test system and other areas                 | 40    |       |
| Documentation | Document the application                    | 24    |       |
| Misc          | Overage of ~20%                             | 50    |       |
|               |                                             |       |       |
| Final Total   |                                             | 312   |       |





### Project Development Notes
This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 1.7.2.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `-prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
