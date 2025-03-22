import React, { useState, useEffect } from "react";
import IssueCard from "./IssueCard";
import useGlobalContext from "../../hooks/useGlobalContext";
import { getData } from "../../services/api";
import { ApiIssue, Issue } from "../../types";

const IssuesList: React.FC = () => {
  const [issues, setIssues] = useState<Issue[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);
  const { user: globalUser } = useGlobalContext();
  console.log(globalUser);
  useEffect(() => {
    const fetchIssues = async () => {
      if (!globalUser?.userId) return;

      try {
        const data = await getData<ApiIssue[]>(
          `Issues?userId=${globalUser.userId}`
        );
        const mappedIssues = data.map((issue: any) => {
          const currentDate = new Date();

          const issueDate = new Date(issue.createdOn);

          const timeDifference = currentDate.getTime() - issueDate.getTime();

          const daysDifference = timeDifference / (1000 * 3600 * 24);
          //if the issue is from today or within the last 3 days
          const isNew = daysDifference <= 3;

          return {
            id: issue.id,
            date: issueDate.toLocaleDateString(),
            title: issue.description,
            type: issue.issueType.name,
            isNew: isNew,
            disabled: issue.status.id !== 1,
          };
        });
        setIssues(mappedIssues);
      } catch (err) {
        console.error(err);
        setError("Failed to load issues");
      } finally {
        setLoading(false);
      }
    };

    fetchIssues();
  }, [globalUser]);

  const handleViewAll = () => {
    console.log("Navigate to all issues page");
  };

  const handleIssueClick = (issueId: number) => {
    console.log(`Clicked on issue ${issueId}`);
  };

  const formatDate = (isoDate: string) => {
    const issueDate = new Date(isoDate)

    const month = (issueDate.getMonth() + 1).toString().padStart(2, "0"); // Months are 0-indexed
    const day = issueDate.getDate().toString().padStart(2, "0");
    const year = issueDate.getFullYear();

    return `${month}/${day}/${year}`;
  }

  const renderIssues = issues.map((issue) => {
    const formattedDate = formatDate(issue.createdOn)

    const isNew = issue.status.name === "Active" ? true : false

    return (
      <IssueCard
        key={issue.id}
        date={formattedDate}
        title={issue.description}
        isNew={isNew}
        onClick={() => !isNew && handleIssueClick(issue.id)}
      />
    )
  })

  return (
    <section className="">
      <div className="flex justify-between items-center mb-5 font-heading">
        <h2 className="text-sm font-bold text-stone-500">Latest Issues</h2>
        <button
          className="text-sm font-bold text-neutral-700 cursor-pointer"
          onClick={() => setViewAllIssues(prev => !prev)}
        >
          {viewAllIssues ? "View Less" : "View all"}
        </button>
      </div>

      {/* Flex Container for Desktop */}
      <div className="hidden md:flex md:flex-wrap md:gap-5">
        {issues.map((issue) => (
          <IssueCard
            key={issue.id}
            date={issue.date}
            title={issue.title}
            type={issue.type}
            isNew={issue.isNew}
            disabled={issue.disabled}
            onClick={() => !issue.disabled && handleIssueClick(issue.id)}
          />
        ))}
      </div>

      <div className="md:hidden overflow-x-auto whitespace-nowrap scroll-smooth bg-background">
        <div className="inline-flex gap-5">
          {issues.map((issue) => (
            <IssueCard
              key={issue.id}
              date={issue.date}
              title={issue.title}
              type={issue.type}
              isNew={issue.isNew}
              disabled={issue.disabled}
              onClick={() => !issue.disabled && handleIssueClick(issue.id)}
            />
          ))}
        </div>

      </div>
    </section >
  );
};

export default IssuesList;
