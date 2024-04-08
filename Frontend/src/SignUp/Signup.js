import React from "react";

import Stepper from '@mui/joy/Stepper';
import Step from '@mui/joy/Step';
import StepButton from '@mui/joy/StepButton';
import StepIndicator from '@mui/joy/StepIndicator';
import Check from '@mui/icons-material/Check';

const steps = ['Order placed', 'In review', 'Approved'];

export default function Signup() {
  const [activeStep, setActiveStep] = React.useState(0); // Initialize activeStep to 0
  const totalSteps = steps.length;

  const handleNext = () => {
    setActiveStep((prevActiveStep) => Math.min(prevActiveStep + 1, totalSteps - 1));
  };

  return (
    
    <div>
      <Stepper sx={{ width: '100%' }}>
        {steps.map((step, index) => (
          <Step
            key={step}
            indicator={
              <StepIndicator
                variant={activeStep <= index ? 'soft' : 'solid'}
                color={activeStep < index ? 'neutral' : 'primary'}
              >
                {activeStep <= index ? index + 1 : <Check />}
              </StepIndicator>
            }
            sx={{
              '&::after': {
                ...(activeStep > index &&
                  index !== totalSteps - 1 && { bgcolor: 'primary.solidBg' }),
              },
            }}
          >
            <StepButton>{step}</StepButton>
          </Step>
        ))}
      </Stepper>
      {/* Next button */}
      <button onClick={handleNext} disabled={activeStep === totalSteps - 1}>Next</button>
    </div>
  );
}
