import { FC, useEffect } from 'react';
import { useProfessionalStore } from '../../stores/professionalStore';

const Index: FC = () => {
  const { professional, loading, fetchProfessional } = useProfessionalStore();

  useEffect(() => {
    fetchProfessional(2);
  }, []);

  if (loading) {
    return <div>Loading...</div>;
  }

  if (!professional) {
    return <div>No data available</div>;
  }

  return (
    <div>
      <h1>{professional.name}</h1>
      <h2>{professional.role}</h2>
      <p>{professional.professionalProfile}</p>
      
      {professional.contact && (
        <div>
          <h3>Contact</h3>
          <p>Email: {professional.contact.email}</p>
          <p>LinkedIn: {professional.contact.linkedIn}</p>
          <p>GitHub: {professional.contact.github}</p>
        </div>
      )}

      {professional.experiences && professional.experiences.length > 0 && (
        <div>
          <h3>Experience</h3>
          {professional.experiences.map((exp) => (
            <div key={exp.id}>
              <h4>{exp.name} - {exp.role}</h4>
              <p>{exp.yearStart} - {exp.yearFinish || 'Present'}</p>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default Index;
