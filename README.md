# Task description

The following actions should be performed as part of this task:
1. CI tool should be set up for execution (Jenkins OR GitHub Actions OR Azure DevOps Pipelines).
1. Pipeline should be created, capable of executing tests with the following triggers (Pipelines as Code approach is strongly preferred, i.e., via YAML, JenkinsFiles definitions):
- On pull request to branch
- By schedule
- By manual start

 3. The whole suite of tests should run on pipeline as follows:
- API and UI tests should run on separate steps of pipeline execution with API being first
- If API tests fail, UI tests should still be executed
- All results and screenshots taken (if any) should be published as artifacts at the end of pipeline run

User should be able to select browser to run UI tests against when manually triggering the run.


